$(function () {
    $("#login-target").submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/Account/Login",
            type: "POST",
            dataType: "json",
            data: $(this).serialize(),
            success: function (result) {
                console.log("test");
                var resultMessage = result;
                $('#result').text(resultMessage);
                location.reload(true);
            }
        });
    //    $.ajax({
    //        type: "GET",
    //        url: "/Account/DoAjax",
    //        success: function (result) {
    //            console.log(result);
    //            $("#result").html(result);
    //        }
    //    });
    //});

    //$('#ajax-test').click(function () {
    //    $.ajax({
    //        type: 'GET',
    //        url: '/Account/HelloAjax',
    //        success: function (result) {
    //            $('#test-result').html(result);
    //        }
    //    });
    });
});