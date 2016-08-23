$(document).on({
    ajaxStart: StartLoading,
    ajaxStop: StopLoading
});

function StartLoading() {
    $(".loading-animation").css({ "display": "block" });
    $("body").addClass("loading");
}

function StopLoading() {
    $(".loading-animation").css({ "display": "none" });
    $("body").removeClass("loading");
}

function LogOff() {
    document.getElementById('logoutForm').submit();
}

function LogFB() {
    $('#logFBForm').submit();
}