
document.addEventListener("DOMContentLoaded", function () {
    $('#form-change-username').validate({
        rules: {
            newUserName: {
                required: true,
                minlength: 5,
                maxlength: 100
            }
        },
        messages: {
            newUserName: {
                required: "Please enter a new userName.",
                minlength: "Your userName must be at least 5 character long.",
                maxlength: "Your userName must be no more than 100 characters long."
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});