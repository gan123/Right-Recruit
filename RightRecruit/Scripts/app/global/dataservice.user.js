define('dataservice.user',
    ['amplify'],
    function (amplify) {
        var init = function () {
            amplify.request.define('login-verify', 'ajax', {
                url: '/rr/login',
                dataType: 'json',
                type: 'POST',
                contentType: 'application/json; charset=utf-8'
            });
            amplify.request.define('logout', 'ajax', {
                url: '/rr/logout',
                type: 'POST'
            });
        };
        
        var login = function(data, callbacks) {
            return amplify.request({
                resourceId: 'login-verify',
                data: data,
                success: callbacks.success,
                error: callbacks.error
            });
        };

        var logout = function(callback) {
            return amplify.request({
                resourceId: 'logout',
                success: callback.success
            });
        };

        init();

        return {
            login: login,
            logout: logout
        };
    });