(function (ns) {
    var
        // Private methods
        sendTheMessage = async function () {
            var sendMsgButton = document.getElementById('send-the-message');
            sendMsgButton.disabled = true;

            var data = {
                name: document.getElementById('Name').value,
                email: document.getElementById('Email').value,
                message: document.getElementById('Message').value,
                subject: document.getElementById('Subject').value,
                phone: document.getElementById('Phone').value
            };
            //var data = {
            //    Name: 'ddd',
            //    Message: 'eee',
            //    Email: 'fff',
            //    Phone: 'ppp',
            //    Subject: 'lll',
            //    Response: 'llo'
            //};

            //jQuery.ajax({
            //    type: "POST",
            //    url: "Cms/Contact",
            //    data: JSON.stringify(data),
            //    contentType: "application/json",
            //    dataType: "json"
            //}).done(function (data) {
            //    toastr.options = {
            //        "closeButton": true,
            //        "debug": false,
            //        "newestOnTop": false,
            //        "progressBar": false,
            //        "positionClass": "toast-bottom-right",
            //        "preventDuplicates": false,
            //        "onclick": null,
            //        "showDuration": "300",
            //        "hideDuration": "1000",
            //        "timeOut": "5000",
            //        "extendedTimeOut": "1000",
            //        "showEasing": "swing",
            //        "hideEasing": "linear",
            //        "showMethod": "fadeIn",
            //        "hideMethod": "fadeOut",
            //        "tapToDismiss": true
            //    };

            //    if (data.success) {
            //        toastr.success('Thank you for contacting us.  Your message has been sent.');
            //    }
            //    else {
            //        toastr.error(data.errorMsg);
            //    }

            //    sendMsgButton.disabled = false;
            //}).fail(function (response) {
            //    console.log('Error');
            //    sendMsgButton.disabled = false;
            //});

            const response = await fetch("Contact", {
                method: 'POST', // *GET, POST, PUT, DELETE, etc.
                //cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                     //'Content-Type': 'application/x-www-form-urlencoded',
                },
                body: JSON.stringify(data) // body data type must match "Content-Type" header
            });

            if (response.status !== 200) return;

            const result = await response.json();

            if (result.success) {
                    toastr.success('Thank you for contacting us.  Your message has been sent.');
                }
                else {
                    toastr.error(result.errorMsg);
                }

                sendMsgButton.disabled = false;


        },

        // Public methods
        init = function () {
            var sendMessage = document.getElementById('send-the-message');

            sendMessage.addEventListener('click', function () {
                sendTheMessage();
            });
        };

    ns.Contact = {
        init: init
    };

})(window.StortfordArchers = window.StortfordArchers || {});