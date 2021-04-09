function logincheck() {
    var loginchk;
    var Password = $(".passwordinput").val();
    var Username = $(".usernameinput").val();


    if (Username == '') {
        $("#usernamewarn").html("Please Enter A Username");
        loginchk = false;
    }
    else {
        $("#usernamewarn").html("");
    }


    if (Password == '') {
        $('#passwordwarn').html("Please Enter A Password");
        loginchk = false;
    }
    else {
        $('#passwordwarn').html("");
    }



    if (loginchk == false) {
        return false;
    }
    else {
        return true;
    }
}
