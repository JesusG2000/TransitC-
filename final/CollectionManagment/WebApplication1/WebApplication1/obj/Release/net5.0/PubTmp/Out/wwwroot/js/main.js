var signInUp_sidebar = {
    view: "sidebar",
    id: 'signInUp',
    type: "customIcons",
    position: "right",
    data: singInUpData,
    on: {
        onAfterSelect: function (id) {
            if ($$('signInUpMultiview')) {
                $$('signInUpMultiview').setValue(id);
            } else {
                $$('cols').removeView('multiview');
                $$('cols').addView(signInUp_multiview, 1);
                $$('signInUpMultiview').setValue(id);
            }
        }
    }
}
var signInUp_multiview = {
    view: 'multiview',
    id: 'signInUpMultiview',
    animate: false,
    cells: singInUp_multiview_data
}

var collection_multivew = {
    view: 'multiview',
    id: 'multiview',
    animate: false,
    cells: collection_multiview_data
};

var left_main_sidebar = {
    view: "sidebar",
    id: 'sidebar',
    scroll:'y',
    type: "customIcons",
    //  collapsedWidth: 60,
    // css: 'sidebar',
    multipleOpen: true,
    data: left_sidebar_items,
    on: {
        onAfterSelect: function (id) {
            if ($$('multiview')) {
                $$('multiview').setValue(id);
            } else {
                $$('cols').removeView('signInUpMultiview');
                $$('cols').addView(collection_multivew, 1);
                $$('multiview').setValue(id);
            }
        }
    },
    ready: function () {
        var firstItem = this.getFirstId();
        this.select(firstItem);
    }
}