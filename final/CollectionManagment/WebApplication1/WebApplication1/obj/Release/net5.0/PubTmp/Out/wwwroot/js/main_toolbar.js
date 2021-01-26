var logout_button = {
    view: 'button',
    id: 'logoutButton',
    type: 'icon',
    icon: 'mdi mdi-exit-run',
    gravity: 1,
    click: function () {
        localStorage.removeItem('jwt');
        actionAfterLogoutUser();
    }
}

var createCollectionButton = {
    view: 'button',
    type: 'button',
    label: 'Create collection',
    gravity: 1,
    click: async function () {
        let result = await isUserLoggedIn();
        if (result.ok) {
            $$("createCollectionPopup").show();
        } else {
            actionIfNotLogIn();
        }
    }
}

var searchBar = {
    view: "search",
    placeholder: "Search..",
    gravity: 5
}

var actionIfNotLogIn = function () {
    
    $$('cols').removeView('multiview')
   
    if (!$$('signInUpMultiview')) {
        $$('cols').addView(signInUp_sidebar, -1)
        $$('cols').addView(signInUp_multiview, 1)
        $$('signInUpMultiview').setValue('singIn');
    }
}

var changeThemeButton = {
    view: 'button',
    type: 'button',
    label: 'White/Dark',
    gravity: 1,
    click: function () {
        var data = document.cookie
        let pathToFlat = '/webix.trial.complete/webix/codebase/skins/flat.css'
        let pathToContrast = "/webix.trial.complete/webix/codebase/skins/contrast.css"
        console.log(data);
        if (data) {
            if (data.includes('contrast')) {
                document.cookie = 'color=' + pathToFlat;
            }
            if (data.includes('flat')) {
                document.cookie = 'color=' + pathToContrast;
            }
        } else {
            document.cookie = 'color=' + pathToFlat;
        }

        var oldlink = document.getElementsByTagName("link").item(2);
        let href = oldlink.href + '';
        var cssFile;

        if (href.includes('contrast')) {
            cssFile = pathToFlat
            localStorage.setItem('theme', 'flat.css')
        } else {
            cssFile = pathToContrast
            localStorage.setItem('theme', 'contrast.css')
        }


        var newlink = document.createElement("link");
        newlink.setAttribute("rel", "stylesheet");
        newlink.setAttribute("type", "text/css");
        newlink.setAttribute("href", cssFile);
        document.getElementsByTagName("head").item(0).replaceChild(newlink, oldlink);


    }
}

var changeLangButton = {
    view: 'button',
    type: 'button',
    label: 'Ru/En',
    gravity: 1
}

var signInUpButton = {
    view: 'button',
    id: 'signInUpButton',
    type: 'button',
    label: 'Sign in/Sign up',
    gravity: 1,
    // width: 1600,
    align: 'left',
    click: function () {
        if ($$('signInUp')) {
            $$('cols').removeView('signInUp');
            $$('cols').removeView('signInUpMultiview');
            if (!$$('multiview')) {
                $$('cols').addView(collection_multivew, 1);
            }
        } else {
            $$('cols').addView(signInUp_sidebar, -1)
            $$('cols').addView(signInUp_multiview, 1)
            $$('cols').removeView('multiview')
        }
    }
}

var menu = {
    view: 'button', type: 'icon', icon: 'mdi mdi-menu', width: 50, align: 'left',
    click: function () {
        $$('sidebar').toggle();
    }
}

var label = {
    view: 'label', label: 'Collection managment', gravity: 2
}