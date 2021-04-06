function searchcheck() {
    var SearchItem = $("#SearchString").val();
    if (SearchItem == '')
    {
        alert("Please Enter A Search Term");
        return false;
    }
}

function BookingConfirmed() {
    alert("Thanks For Booking!");
}

function logincheck() {
    var Password = $(".password").val();
    var username = $(".username").val();

    if (username == '' && Password == '') {
        alert("Please Enter A Username & Password!")
        return false;
    }

    else if (Password == '') {
        alert("Please Enter A Password!");
        return false;
    }

    else if (username == '') {
        alert("Please Enter A Username!")
        return false;
    }


}