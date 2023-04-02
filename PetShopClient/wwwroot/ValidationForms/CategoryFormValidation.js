
    document.addEventListener('DOMContentLoaded', function () {
        $('form').validate({
            rules: {
                CategoryName: {
                    required: true,
                    minlength: 5,
                    maxlength: 30
                }
            },
            messages: {
                CategoryName: {
                    required: "Please enter a category name.",
                    minlength: "Category name must be at least 5 characters long.",
                    maxlength: "Category name cannot be more than 30 characters long."
                }
            },
            errorClass: "error-message"
        });
    });
  