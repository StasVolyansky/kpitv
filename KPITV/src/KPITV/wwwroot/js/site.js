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

$(document).ready(function () {
    $(".settings-info input").change(function () {
        $.ajax({
            method: "post",
            url: "settings",
            data: {
                param: $(this).attr("name"),
                value: $(this).val()
            }
        });
    });
});