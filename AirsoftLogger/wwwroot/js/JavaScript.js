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

var TopofPage = document.getElementById("Top");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        TopofPage.style.display = "block";
    } else {
        TopofPage.style.display = "none";
    }
}

function toppage() {
    document.body.scrollTop = 0; 
    document.documentElement.scrollTop = 0; 
}