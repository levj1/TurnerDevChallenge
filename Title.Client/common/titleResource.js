(function () {
    "use strict";
    angular
        .module("common.services")
         .factory("titleResource",
                    ["$resource",
                      "appSettings",
                      titleResource])
    function titleResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/titles/:id");
    }
}());