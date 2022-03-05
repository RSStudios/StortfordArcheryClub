(function (ns) {
    var

        // Public methods
       
        init = function () {

        },
        populateLargeCalendar = function (dateVal) {
            $('.spinner').show();

            $.ajax({
                type: 'GET',
                url: "/Cms/LargeCalendar",
                data: { date: dateVal }
            }).done(function (data) {
                $('#prev-month-name').html(data.PrevMonthName);
                $('#month-name').html(data.MonthName);
                $('#next-month-name').html(data.NextMonthName);
                $('#prev-month-value').val(data.PrevMonth);
                $('#next-month-value').val(data.NextMonth);
                $('#large-calendar-placeholder').html($.parseHTML(data.html));
                $('.spinner').hide();
                setupClickableLiOnLargeCalendar();
            }).error(function (error) {
                $('.spinner').hide();
            });
        },
        populateSmallCalendar = function (dateVal) {
            $.ajax({
                type: 'GET',
                url: "/Training/SmallCalendar",
                data: { date: dateVal }
            }).done(function (data) {
                $('#month-name').html(data.MonthName);
                $('#small-calendar-placeholder').html($.parseHTML(data.html));
            }).error(function (error) {
                var a;
                a = "";
            });
        },
        setupClickableLiOnLargeCalendar = function () {
            $(".days-of-months li.has-valid-day-of-month").off('click').on('click', function () {
                var url = $(this).attr("data-url");
                window.location = url;
            });
        },
        setupLargeCalendar = function () {
            $("#prev-month-large-calendar, #prev-month-name").off('click').on('click', function () {
                populateLargeCalendar($('#prev-month-value').val());
            });

            $("#next-month-large-calendar, #next-month-name").off('click').on('click', function () {
                populateLargeCalendar($('#next-month-value').val());
            });
        },
        setupSmallCalendar = function () {
            $("#prev-month-small-calendar").off('click').on('click', function () {
                populateSmallCalendar($('#prev-month-value').val());
            });

            $("#next-month-small-calendar").off('click').on('click', function () {
                populateSmallCalendar($('#next-month-value').val());
            });
        };

    ns.Training = {
        init: init,
        populateLargeCalendar: populateLargeCalendar,
        populateSmallCalendar: populateSmallCalendar,
        setupLargeCalendar: setupLargeCalendar,
        setupSmallCalendar: setupSmallCalendar,
       };

})(window.FLD = window.FLD || {});