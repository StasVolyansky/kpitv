$(document).ready(function () {
    $(".stuff-card").click(function () {
        location.href = $(this).attr('data-href');
    });
});