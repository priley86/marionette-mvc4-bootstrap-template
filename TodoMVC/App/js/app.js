/*global $*/
define(
  ['marionette','vent','./pages/home/collections/TodoList','./pages/home/views/Header','./pages/home/views/TodoListCompositeView','./pages/home/views/Footer'],
  function(marionette, vent, TodoList, Header, TodoListCompositeView, Footer){
    "use strict";

    var app = new marionette.Application();

    app.addRegions({
      regionMain   : '#appmain',
    });

    return app;
  }
);
