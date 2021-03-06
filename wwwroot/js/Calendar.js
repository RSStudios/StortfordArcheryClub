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
    const calendarPlaceholder = document.querySelector('.large-calendar-placeholder');
    const spinner = document.querySelector('.spinner');
    const monthName = document.getElementById('month-name');
    const prevMonthName = document.getElementById('prev-month-name');
    const prevMonth = document.getElementById('prev-month-value');
    const nextMonthName = document.getElementById('next-month-name');
    const nextMonth = document.getElementById('next-month-value');

    fetch("/Cms/LargeCalendar?" + new URLSearchParams({ date: dateVal, pageId, calendarBlockId }),
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
            spinner.style.display = 'none';

            if (data === null || data === undefined) return;

            if (data.errors === undefined && data.html !== "") {
                calendarPlaceholder.innerHTML = data.html;
                monthName.innerHTML = data.monthName;
                prevMonthName.innerHTML = data.prevMonthName;
                nextMonthName.innerHTML = data.nextMonthName;
                prevMonth.value = data.prevMonth;
                nextMonth.value = data.nextMonth;
                setupPopUpOnClick();
            }
            else {
                const container = calendarPlaceholder.closest('.container');
                if (container !== undefined) {
                    container.style.display = 'none';
                }
            }
        }).catch((error) => {
            console.error('Error: ', error);
            spinner.style.display = 'none';

            const calendar = document.getElementById('large-calendar');
            calendar.style.display = 'none';
        });
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
/*
 * Upcoming events
 */
export function setupUpcomingEvents() {
    
    populateUpcomingEvents();
}
function populateUpcomingEvents(dateVal) {
    $('.spinner').show();
    const pageId = document.getElementById('page-id').value;
    const upcomingEventsBlockId = document.getElementById('upcoming-events-block-id').value;
    const upcomingeventsPlaceholder = document.querySelector('.upcoming-events-placeholder');
    const spinner = document.querySelector('.upcoming-spinner');
    //const monthName = document.getElementById('month-name');
    //const prevMonthName = document.getElementById('prev-month-name');
    //const prevMonth = document.getElementById('prev-month-value');
    //const nextMonthName = document.getElementById('next-month-name');
    //const nextMonth = document.getElementById('next-month-value');

    fetch("/Cms/UpcomingEvents?" + new URLSearchParams({ date: dateVal, pageId, upcomingEventsBlockId }),
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
            spinner.style.display = 'none';

            if (data === null || data === undefined) return;

            if (data.errors === undefined && data.html !== "") {
                upcomingeventsPlaceholder.innerHTML = data.html;
                setupEventPopUpOnClick();
            }
            else {
                const container = calendarPlaceholder.closest('.container');
                if (container !== undefined) {
                    container.style.display = 'none';
                }
            }
        }).catch((error) => {
            console.error('Error: ', error);
            spinner.style.display = 'none';

            const calendar = document.getElementById('upcoming-events');
            calendar.style.display = 'none';
        });
}
function setupEventPopUpOnClick() {
    document.querySelectorAll('.event-popup').forEach(item => {
        item.addEventListener('click', el => {
            let id = el.target.dataset.id;
            let dt = el.target.dataset.date;
            if (el.target.dataset.id === undefined) {
                id = el.target.closest('.upcoming-event').dataset.id;
                dt = el.target.closest('.upcoming-event').dataset.date;
            }
            const theDialog = document.querySelector(`#event-modal`);
            const template = document.querySelector(`#template-day-id-${id}`);
            const dialogContent = document.querySelector('#event-modal .content');
            const dialogEvent = document.querySelector('#events');
            dialogEvent.innerHTML = `Events for ${dt}`;
            dialogContent.innerHTML = template.innerHTML;
            const dialog = new A11yDialog(theDialog);
            dialog.show();
        });
    });
}