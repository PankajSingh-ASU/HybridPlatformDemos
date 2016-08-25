function Navigation(_args) {
    var that = this;
    _args = _args || {};
    this.parent = _args.parent;
    this.controllers = [], this.currentController = null;
    this.currentControllerArguments = {};
    this.push = function(_controller, _controllerArguments) {
        if ("string" == typeof _controller) var controller = Alloy.createController(_controller, _controllerArguments); else var controller = _controller;
        that.currentController = controller;
        that.currentControllerArguments = _controllerArguments;
        that.controllers.push(controller);
        that.parent.openWindow(controller.window);
        return controller;
    }, this.pop = function() {
        var controller = that.controllers.pop();
        var window = controller.window;
        that.parent.closeWindow(window);
        controller.destroy();
    }, this.openModal = function(_controller, _controllerArguments) {
        var controller = Alloy.createController(_controller, _controllerArguments);
        that.currentController = controller;
        that.currentControllerArguments = _controllerArguments;
        controller.window.open({
            modal: true,
            animated: false
        });
        return controller;
    }, this.closeModal = function(_controller) {
        _controller.window.close();
        _controller.window = null;
        _controller.destroy();
        _controller = null;
    };
}

module.exports = function(_args) {
    return new Navigation(_args);
};