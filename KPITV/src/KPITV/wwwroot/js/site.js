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