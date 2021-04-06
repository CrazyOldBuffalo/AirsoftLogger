$(document).ready(function () {
    var TopofPage = document.getElementById("Top");

    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            TopofPage.style.display = "block";
        } else {
            TopofPage.style.display = "none";
        }
    }


});

function toppage() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}