$(document).ready(function () {
    var slideIndex = 0;
    showSlides();

    function showSlides() {
        var i;
        var slides = $(".mySlides");
        console.log(slides.length)
        for (i = 0; i < slides.length; i++) {
            slides.eq(i).hide();
        }
        slideIndex++;
        if (slideIndex > slides.length) { slideIndex = 1 }
        slides.eq(slideIndex - 1).show();
        setTimeout(showSlides, 4000);
    }
});




//function showslides() {
//    var i;
//    var slides = document.getelementsbyclassname("myslides");
//    for (i = 0; i < slides.length; i++) {
//        slides[i].style.display = "none";
//    }
//    slideindex++;
//    if (slideindex > slides.length) { slideindex = 1 }
//    slides[slideindex - 1].style.display = "block";
//    settimeout(showslides, 2000);
//}

