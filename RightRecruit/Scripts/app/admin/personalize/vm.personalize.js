define('vm.personalize',
    ['jquery', 'ko', 'dataservice.admin', 'amplify'],
    function($, ko, adminService, amplify) {
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
                    amplify.request('personalize-save', ko.toJSON(buildData()))
                        .done(function (data, status) {
                            location.reload();
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
                adminService.init();
                amplify.request('personalize-get')
                    .done(function (data, status) {
                        console.log(data);
                        basicColor(data.Branding.Theme.BasicColor);
                        midColor(data.Branding.Theme.MidColor);
                        boldColor(data.Branding.Theme.BoldColor);
                        controlBorderColor(data.Branding.Theme.ControlBorderColor);
                        foregroundColor(data.Branding.Theme.ForegroundColor);
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