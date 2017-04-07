(function () {
    "use strict";
    angular
        .module("common.services",
                    ["ngResource"])
        .constant("appSettings",
        {
            // url for accessing API
            serverPath: "http://localhost:64370/"
        });
}());