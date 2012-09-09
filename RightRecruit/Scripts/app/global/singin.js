define('signin',
    ['jquery', 'dataservice.user', 'ko'],
    function ($, userService, ko) {
        var init = function() {
            $(function () {
                $(".signin").click(function (e) {
                    e.preventDefault();
                    $("div#signin_menu").toggle();
                    $(".signin").toggleClass("menu-open");
                });

                $("div#signin_menu").mouseup(function () {
                    return false;
                });
                $(document).mouseup(function (e) {
                    if ($(e.target).parent("a.signin").length == 0) {
                        $(".signin").removeClass("menu-open");
                        $("div#signin_menu").hide();
                    }
                });
                $(".menuitem").click(function () {
                    $(".menuitem").each(function () {
                        $(this).attr('class', 'menuitem inactive');
                    });
                    $(this).attr('class', 'menuitem active');
                });

                $("#signin").click(function () {
                    var login = {
                        login: $("#username").val(),
                        password: $("#password").val(),
                        rememberme: $("#remember:checked").val() == 1 ? true : false
                    };
                    userService.login(ko.toJSON(login), {
                        success: function (result) {
                            window.location = '/rr/inbox';
                        },
                        error: function (result) {

                        }
                    });
                });
            });
        };

        return {
          init : init  
        };
});