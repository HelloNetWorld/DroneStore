function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#image-catalog-item-preview').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#catalog-item-input-file").change(function () {
    readURL(this);
});

$("#create-catalog-item-form").validate({
    rules: {
        Name: "required",
        Price: "required",
        Brand: {
            required: true,
            maxlength: 150
        },
        Quantity: "required",
    },

    messages: {
        Name: "Please enter Name",
        Price: "Please enter Price",
        Brand: {
            required: "Please enter address",
            maxlength: "Your address must be below 250 characters"
        },
        Quantity: "Please enter quantity",
    },

    submitHandler: function (form) {
        form.submit();
    }
});

$("#edit-discount").validate({
    rules: {
        ExpireDate: "required",
        NewPrice: "required",
        OldPrice: "required"
    },

    messages: {
        ExpireDate: "Please enter Expire Date",
        NewPrice: "Please enter New Price",
        OldPrice: "Please enter Old Price"
    },

    submitHandler: function (form) {
        form.submit();
    }
});

$("#edit-user").validate({
    rules: {
        UserName: "required",
        Email: {
            required: true,
            email: true
        },
        Roles: "required"
    },

    messages: {
        UserName: "Please enter User Name",
        Email: {
            required: "Please enter email address",
            email: "Please enter valid email address"
        },
        Roles: "Please enter Roles"
    },

    submitHandler: function (form) {
        form.submit();
    }
});