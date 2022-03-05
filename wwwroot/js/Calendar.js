import A11yDialog from '../js/Modal.js'

export function setupLargeCalendar() {
    const prevMonthName = document.getElementById('prev-month-name');
    const nextMonthName = document.getElementById('next-month-name');
    prevMonthName.addEventListener('click', handleLargeCalendarPrevClick);
    nextMonthName.addEventListener('click', handleLargeCalendarNextClick);

    const prevMonth = document.getElementById('prev-month-large-calendar');
    const nextMonth = document.getElementById('next-month-large-calendar');
    prevMonth.addEventListener('click', handleLargeCalendarPrevClick);
    nextMonth.addEventListener('click', handleLargeCalendarNextClick);
    populateLargeCalendar();
}

export function calendarPopUp(e) {
    alert("he");
}
function handleLargeCalendarPrevClick() {
    const prevMonthValue = document.getElementById('prev-month-value');
    populateLargeCalendar(prevMonthValue.value);
}

function handleLargeCalendarNextClick() {
    const nextMonthValue = document.getElementById('next-month-value');
    populateLargeCalendar(nextMonthValue.value);
}
function populateLargeCalendar(dateVal) {
    $('.spinner').show();
    const pageId = document.getElementById('page-id').value;
    const calendarBlockId = document.getElementById('calendar-block-id').value;
    const calendarPlaceholder = document.getElementById('large-calendar-placeholder');
    const spinner = document.querySelector('.spinner');
    const monthName = document.getElementById('month-name');
    const prevMonthName = document.getElementById('prev-month-name');
    const prevMonth = document.getElementById('prev-month-value');
    const nextMonthName = document.getElementById('next-month-name');
    const nextMonth = document.getElementById('next-month-value');

    

    fetch("/Cms/LargeCalendar?" + new URLSearchParams({date: dateVal, pageId, calendarBlockId}),
        {
            method: 'GET',
            headers: new Headers({
                'content-type': 'application/json'
            })
           
        }).then((response) => {
            if (response.status === 200 || response.status === 400) {
                return response.text().then(function (text) {
                    const result = text ? JSON.parse(text) : {};
                    result.statusCode = response.status;
                    return result;
                });
            }
        }).then(data => {
            if (data.errors === undefined) {
                calendarPlaceholder.innerHTML = data.html;
                monthName.innerHTML = data.monthName;
                prevMonthName.innerHTML = data.prevMonthName;
                nextMonthName.innerHTML = data.nextMonthName;
                prevMonth.value = data.prevMonth;
                nextMonth.value = data.nextMonth;
                spinner.style.display = 'none';
                setupPopUpOnClick();
            }
        });
    //$.ajax({
    //    type: 'GET',
    //    url: "/Training/LargeCalendar",
    //    data: { date: dateVal }
    //}).done(function (data) {
    //    $('#prev-month-name').html(data.PrevMonthName);
    //    $('#month-name').html(data.MonthName);
    //    $('#next-month-name').html(data.NextMonthName);
    //    $('#prev-month-value').val(data.PrevMonth);
    //    $('#next-month-value').val(data.NextMonth);
    //    $('#large-calendar-placeholder').html($.parseHTML(data.html));
    //    $('.spinner').hide();
    //    setupClickableLiOnLargeCalendar();
    //}).error(function (error) {
    //    $('.spinner').hide();
    //});
}

function setupPopUpOnClick() {
    document.querySelectorAll('.calendar-popup').forEach(item => {
        item.addEventListener('click', el => {
            const theDialog = document.querySelector(`#calendar-modal`);
            const template = document.querySelector(`#template-day-id-${el.target.dataset.id}`);
            const dialogContent = document.querySelector('#calendar-modal .content');
            const dialogEvent = document.querySelector('#events');
            dialogEvent.innerHTML = `Events for ${el.target.dataset.date}`;
            dialogContent.innerHTML = template.innerHTML;
            const dialog = new A11yDialog(theDialog);
            dialog.show();
        });
    });
}