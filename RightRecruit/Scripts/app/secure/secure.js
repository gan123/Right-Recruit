$(function () {
    requirejs(['vm.secure', 'binder'], load);
    
    function load() {
        require(['vm.secure', 'binder'], function (vm, b) {
            b.bind(vm, "#login-view");
        });
    }
})