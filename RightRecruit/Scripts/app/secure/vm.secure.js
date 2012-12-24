define('vm.secure',
    ['jquery', 'ko', 'model.user', 'amplify', 'dataservice.secure'],
    function($, ko, userModel, amplify, secureService) {
        var user = ko.observable(new userModel().UserName("").Password("")),
            validationErrors = ko.validation.group(user()),
            isValid = ko.computed(function () {
                console.log(validationErrors().length);
                return validationErrors().length === 0;
            }),
            loginCommand = ko.asyncCommand({
                execute: function (complete) {
                    amplify.request('login', ko.toJSON({ login: user().UserName, password: user().Password, rememberme: user().RememberMe }))
                        .done(function(data, status) {
                            if (status == 'success') {
                                window.location = '/rr/home';
                            }
                        })
                        .fail(function (data, status) {
                            console.log(status);
                        });
                    complete();
                },
                canexecute: function(isExecuting) {
                    return !isExecuting && isValid();
                }
            }),
            init = function() {
                secureService.init();
            };

        init();
        return {
            user: user,
            loginCommand: loginCommand,
            isValid: isValid
        };
    });