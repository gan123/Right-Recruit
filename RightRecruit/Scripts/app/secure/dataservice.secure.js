define('dataservice.secure',
    ['amplify'],
    function(amplify) {
        var init = function() {
            amplify.request.define('login', 'ajax', {
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

        return {
          init: init  
        };
    });