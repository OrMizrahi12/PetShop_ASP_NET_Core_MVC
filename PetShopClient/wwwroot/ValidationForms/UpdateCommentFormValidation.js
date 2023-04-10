
document.addEventListener("DOMContentLoaded", function () {
    $('#update-comment-form').validate({
        rules: {
            Comment: {
                required: true,
                minlength: 5,
                maxlength: 100
            }
        },
        messages: {
            Comment: {
                required: "Please enter a comment.",
                minlength: "Your comment must be at least 5 character long.",
                maxlength: "Your comment must be no more than 100 characters long."
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});