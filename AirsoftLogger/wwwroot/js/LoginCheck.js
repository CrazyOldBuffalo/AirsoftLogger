﻿function logincheck() {
    var Password = $(".passwordinput").val();
    var username = $(".usernameinput").val();

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