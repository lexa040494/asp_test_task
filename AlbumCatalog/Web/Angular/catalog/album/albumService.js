(function () {
    "use strict";

    function albumService($cookies, $http, $rootScope, $q) {
        var service = {};

        return service;
    };

    angular
        .module("Web.Services")
        .service("albumService", ["$cookies", "$http", "$rootScope", "$q", albumService]);
})();
