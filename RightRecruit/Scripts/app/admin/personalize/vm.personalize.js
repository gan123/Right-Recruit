define('vm.personalize',
    ['jquery', 'ko', 'dataservice.admin'],
    function($, ko, adminService) {
        var logo = ko.observable(),
            appHeader = ko.observable(),
            callbackLink = ko.observable(),
            favIcon = ko.observable(),
            basicColor = ko.observable(),
            onBasicColorChange = function (hsb, hex, rgb) {
                basicColor("#" + hex);
                $('#basic').css('backgroundColor', '#' + hex);
                $('.menu-mini').css('backgroundColor', '#' + hex);
            },
            midColor = ko.observable(),
            onMidColorChange = function (hsb, hex, rgb) {
                midColor("#" + hex);
                $('#mid').css('backgroundColor', '#' + hex);
            },
            boldColor = ko.observable(),
            onBoldColorChange = function (hsb, hex, rgb) {
                boldColor("#" + hex);
                $('#bold').css('backgroundColor', '#' + hex);
            },
            controlBorderColor = ko.observable(),
            onControlBorderColorChange = function (hsb, hex, rgb) {
                controlBorderColor("#" + hex);
                $('#controlBorder').css('backgroundColor', '#' + hex);
            },
            foregroundColor = ko.observable(),
            onForegroundColorChange = function (hsb, hex, rgb) {
                foregroundColor("#" + hex);
                $('#foreground').css('backgroundColor', '#' + hex);
            },
            saveCommand = ko.asyncCommand({
                execute: function (complete) {
                    adminService.savePersonalization(buildData(), {
                       success: function (response) {
                           location.reload();
                       },
                       error: function (response) {
                           
                       }
                    });
                    complete();
                },
                canexecute: function (isExecuting) {
                    return !isExecuting;
                }
            }),
            cancelCommand = ko.asyncCommand({
                execute: function (complete) {
                    window.location = '/rr/admin';
                    complete();
                },
                canexecute: function (isExecuting) {
                    return !isExecuting;
                }
            }),
            init = function () {
                adminService.getPersonalization({
                    success: function (response) {
                        basicColor(response.Branding.Theme.BasicColor);
                        midColor(response.Branding.Theme.MidColor);
                        boldColor(response.Branding.Theme.BoldColor);
                        controlBorderColor(response.Branding.Theme.ControlBorderColor);
                        foregroundColor(response.Branding.Theme.ForegroundColor);
                    },
                    error: function (response) {
                        
                    }
                });
            },
            buildData = function () {
                return {
                    BasicColor: basicColor,
                    MidColor: midColor,
                    BoldColor: boldColor,
                    ControlBorderColor: controlBorderColor,
                    ForegroundColor: foregroundColor
                };
            };

        init();
        
        return {
            logo: logo,
            appHeader: appHeader,
            callbackLink: callbackLink,
            favIcon: favIcon,
            basicColor: basicColor,
            midColor: midColor,
            boldColor: boldColor,
            foregroundColor: foregroundColor,
            controlBorderColor: controlBorderColor,
            saveCommand: saveCommand,
            cancelCommand: cancelCommand,
            onBasicColorChange: onBasicColorChange,
            onMidColorChange: onMidColorChange,
            onBoldColorChange: onBoldColorChange,
            onControlBorderColorChange: onControlBorderColorChange,
            onForegroundColorChange: onForegroundColorChange
        };
    });