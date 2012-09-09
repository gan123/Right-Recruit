define('signout',
    ['dataservice.user'],
    function (userService) {
        var init = function() {
            $("#signout").click(function () {
                userService.logout({
                    success: function () {
                        window.location = '/rr/home';
                    }
                });
            });
        };

        return {
            init: init
        };
    });