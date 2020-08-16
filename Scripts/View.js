var dnnSpa = dnnSpa || {};

dnnSpa.viewModel = function (moduleId, resx) {
    var service = {
        path: "starter-module-spa",
        framework: $.ServicesFramework(moduleId)
    }
    service.baseUrl = service.framework.getServiceRoot(service.path);

    var init = function () {
        sayHello();
    };

    var sayHello = function () {
        $.ajax({
            url: service.baseUrl + "My/DnnHello/",
            type: "GET",
            beforeSend: service.framework.setModuleHeaders,
            dataType: "json"
        }).done(function (data) {
            if (data) {
                $('#myModule-' + moduleId + ' .message').html(data);
            }
            else {
                $('#myModule-' + moduleId + ' .message').html('Something went wrong with the DnnHello Web API call!');
            }
        });
    };

    var sayHelloPersonalize = function (e) {
        e.preventDefault();
        $.ajax({
            url: service.baseUrl + "My/DnnHelloPersonalize/",
            type: "POST",
            beforeSend: service.framework.setModuleHeaders,
            dataType: "json",
            data: { name: $('#myModule-' + moduleId + ' .name').val() }
        }).done(function (data) {
            if (data) {
                $('#myModule-' + moduleId + ' .message').html(data);
            }
            else {
                $('#myModule-' + moduleId + ' .message').html('Something went wrong with the DnnHelloPersonalize Web API call!');
            }
        });
    };

    return {
        init: init,
        sayHello: sayHello,
        sayHelloPersonalize: sayHelloPersonalize
    }
};