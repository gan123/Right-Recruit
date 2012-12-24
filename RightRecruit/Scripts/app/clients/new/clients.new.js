$(function () {
    requirejs(['vm.clients.create', 'binder'], load);

    $("#cancel").click(function () {
        window.location = '/rr/clients';
    });

    function load() {
        require(['vm.clients.create', 'binder'], function (vm, b) {
            console.log('in');
            b.bind(vm, "#clients-create");
        });
    }
    
    var currentStepIndex = 1;
    var totalSteps = 5;

    initialize();

    $("#next").click(function () {
        $("#view" + currentStepIndex).hide();
        toggleStep();
        currentStepIndex++;
        if (currentStepIndex > 1 && currentStepIndex < totalSteps) {
            $("#previous").show();
        } else if (currentStepIndex == totalSteps) {
            $("#next").hide();
            $("#create").show();
        }
        $("#view" + currentStepIndex).fadeIn('slow');
        toggleStep();
    });

    $("#previous").click(function () {
        $("#view" + currentStepIndex).hide();
        toggleStep();
        currentStepIndex--;
        if (currentStepIndex == 1) {
            $("#previous").hide();
        } else if (currentStepIndex < totalSteps) {
            $("#next").show();
            $("#create").hide();
        }
        $("#view" + currentStepIndex).fadeIn('slow');
        toggleStep();
    });

    $("#create").click(function () {
        $(".wizardButton").hide();
        $(".view").hide();
        $("#recreate").show();
        $("#complete").show();
        toggleStep();
    });

    $("#recreate").click(initialize);

    function toggleStep() {
        if (currentStepIndex <= totalSteps) {
            $("#step" + currentStepIndex).toggleClass(currentStepIndex == 1 ? 'stepActiveFirst' : 'stepActive');
        }
    }

    function initialize() {
        $(".view").hide();
        $(".wizardButton").hide();
        $("#next").show();
        $("#view1").show();
        $(".step").removeClass('stepActiveFirst');
        $(".step").removeClass('stepActive');
        $("#step1").toggleClass('stepActiveFirst');
    }
})