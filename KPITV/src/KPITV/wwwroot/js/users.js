$(document).ready(function () {
    $('.role-toggler').change(function () {
        $.ajax({
            method: 'post',
            url: "/users/changeRole",
            data: {
                'name': $(this).attr('id'),
                'role': $(this).attr('name'),
                'hasRole': $(this).attr('name') == 'User' ? !$(this).prop('checked') : $(this).prop('checked')
            }
        });
    });
});