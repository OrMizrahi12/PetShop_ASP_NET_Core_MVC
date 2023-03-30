document.addEventListener('DOMContentLoaded', function () {
    // Add CSS for error messages
    $.validator.setDefaults({
        errorClass: 'text-danger',
    });

    $.validator.addMethod("fileType", function (value, element) {
        var maxSize = 5 * 1024 * 1024; // 5 MB
        if (element.files.length > 0) {
            var file = element.files[0];
            var fileType = file.type.match(/^image\//);
            if (!fileType) {
                return false;
            }
            if (file.size > maxSize) {
                this.message = "File size must not exceed 5 MB";
                return false;
            }
        }
        return true;
    }, "");

    // Initialize form validation
    var validator = $("form").validate({
        rules: {
            Name: {
                required: true,
                minlength: 2,
                maxlength: 20
            },
            Age: {
                required: true,
                min: 0,
                max: 100,
                digits: true,
            },
            ImageFile: {
                required: true,
                fileType: true,
            },
            Description: {
                required: true,
                minlength: 10,
                maxlength: 255,
            },
            CategoryId: {
                required: true,
            },
        },
        messages: {
            Name: {
                required: "Please enter a name",
                minlength: "Name must be at least 2 - 20",
            },
            Age: {
                required: "Please enter an age",
                min: "Age must be at least 0 - 100",
                digits: "Please enter a whole number",
            },
            ImageFile: {
                required: "Please choose an image",
            },
            Description: {
                required: "Please write a description 10 - 255 chars",
            },
            CategoryId: {
                required: "Please select a category",
            },
        },
    });

    // Handle form submission
    $("#submitBtn").on("click", function (e) {
        e.preventDefault();

        if (validator.form()) { // Check if form is valid
            $("form").trigger("submit");
            alert("The animal has been added!");
        } else {
            // Show alert if form is invalid
            alert("Please correct the errors in the form before submitting.");
        }
    });
});
