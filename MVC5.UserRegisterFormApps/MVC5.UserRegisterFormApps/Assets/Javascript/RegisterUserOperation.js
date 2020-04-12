function checkEmailAddress() {
    var emailAddressText = $("#emailAddress").val();
    $.ajax({
        type: 'GET',
        url: '/JsonOperation/checkEmailAddress',
        datatype: JSON,
        data: {
            'emailAddressVal': emailAddressText
        },
        success: function (data) {
            if (data.isSuccess == false) {
                alert(data.message);
                $("#emailAddress").val('');
            }
        },
        error: function (data) { }
    });  
    console.log(emailAddressTextII);
}