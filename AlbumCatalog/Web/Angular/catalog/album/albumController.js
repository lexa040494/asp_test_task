/// <reference path="topMenuDirective/topMenu.js" />
(function () {
    "use strict";

    // controller class definintion
    var albumController = function ($scope, $rootScope, storeService, productService, uiGridConstants, $uibModal) {
       
    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("albumController", ["$scope", "$rootScope", "storeService", "productService", "uiGridConstants", "$uibModal", albumController]);

})();