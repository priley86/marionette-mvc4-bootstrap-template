define(['marionette','vent','app'], function (marionette,vent,app) {
    'use strict';

    return marionette.AppRouter.extend({
        routes: {
            '' : 'home',
            '*filter': 'homeSetFilter'
        },

        home: function() {
            this._showPage('home');
        },

        homeSetFilter: function(param) {
            vent.trigger('todoList:filter', param.trim() || '');
        },


        _showPage: function (pageName, options) {
            var that = this;

            require(['./pages/' + pageName + '/Controller'], function (PageController) {
                if (that.currentPageController) {
                    that.currentPageController.close();
                    that.currentPageController = null;
                }

                vent.trigger('overlay:reset');
                vent.trigger('overlay:show');

                that.currentPageController = new PageController(options);

                that.currentPageController.show(app.regionMain)
                    .always(function () {
                        vent.trigger('overlay:hide');
                    })
                    .fail(function () {
                        //display the not found page
                        that.navigate('/not-found', { trigger: true, replace: true });
                    });

            });
        }

    });

    return Router;
});