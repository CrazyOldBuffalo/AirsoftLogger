function SiteCheck() {
    var sitecheck;
    var sitecode = $(".siteCode").val();
    var city = $(".City").val();
    var tel = $(".Tel").val();
    var postcode = $(".PostCode").val();
    var sitename = $(".siteName").val();

    if (sitecode == "" || sitecode.length < 2) {
        $("#sitecodewarn").show();
        $("#sitecodewarn").html("A Site MUST have a Valid Sitecode");
        sitecheck = false;
    }
    else {
        $("#sitecodewarn").hide();
    }

    if (city == "" || city.length < 2) {
        $("#sitecitywarn").show();
        $("#sitecitywarn").html("A Site MUST have a Valid City");
        sitecheck = false;
    }
    else {
        $("#sitecitywarn").hide();
    }


    if (tel == "" || tel.length < 4) {
        $("#sitetelwarn").show();
        $("#sitetelwarn").html("A Site MUST have a Valid Contact Number");
        sitecheck = false;
    }
    else {
        $("#sitetelwarn").hide();
    }

    if (postcode == "" || postcode.length < 4) {
        $("#sitepostcodewarn").show();
        $("#sitepostcodewarn").html("A Site MUST have a Valid Postcode");
        sitecheck = false;
    }
    else {
        $("#sitepostcodewarn").hide();
    }

    if (sitename == "" || sitename.length < 4) {
        $("#sitenamewarn").show();
        $("#sitenamewarn").html("A Site MUST have a Valid Name");
        sitecheck = false;
    }
    else {
        $("#sitenamewarn").hide();
    }

    if (sitecheck == false) {
        return false;
    }
    else {
        alert("Site Created");
        return true;
    }
}

function EventCheck() {
    var currentdate = new Date().toISOString().slice(0,10);
    var eventCheck;
    var sitecode = $(".siteCode").val();
    var date = $(".Date").val();
    var spaces = parseInt($(".Spaces").val());

    if (sitecode == "" || sitecode.length <= 2) {
        $("#eventsitecodewarn").show();
        $("#eventsitecodewarn").html("Please Enter A Valid Sitecode");
        eventCheck = false;
    }
    else {
        $("#eventsitecodewarn").hide();
    }


    if (date == "" || date < currentdate) {
        $("#eventsitecodewarn").show();
        $("#eventdatewarn").html("Please Enter A Valid Date");
        eventCheck = false;
    }
    else {
        $("#eventsitecodewarn").hide();
    }

    if (spaces == "" || spaces < 1) {
        $("#eventsitecodewarn").show();
        $("#eventspaceswarn").html("Please Enter a Valid Number of Spaces");
        eventCheck = false;
    }
    else {
        $("#eventsitecodewarn").hide();
    }

    if (eventCheck == false) {
        return false;
    }
    else {
        alert("Event Created");
        return true;
    }
}