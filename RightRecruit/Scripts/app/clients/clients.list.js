$(function () {
    $("#clients").attr('class', 'menuitem active');
    requirejs(['vm.clients.list', 'binder'], load);

    function load() {
        require(['vm.clients.list', 'binder'], function (vm, b) {
            b.bind(vm, "#clients-view");
        });
    }
})