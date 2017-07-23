/// <reference path="appConfig.js" />
(function () {
    "use strict";

    angular
        .module("Web")
        .config(["$stateProvider", "$urlRouterProvider", "$locationProvider", function ($stateProvider, $urlRouterProvider, $locationProvider) {
            // Index
            $stateProvider.state("/album", {
                url: "/album",
                templateUrl: function () { return "Angular/catalog/album/album.html?" + new Date(); },
                controller: "albumController"
            });
        }]);
})();