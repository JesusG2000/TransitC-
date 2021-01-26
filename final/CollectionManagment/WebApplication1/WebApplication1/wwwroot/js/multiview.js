var imgPath;

var left_sidebar_items = [
    {
        id: "home", icon: "mdi mdi-home", value: "Home", data: [
            {
                id: 'collections', icon: 'mdi mdi-rhombus-split', value: 'Collections', data: [
                    { id: 'all', icon: 'mdi mdi-database-search-outline', value: 'All' },
                    { id: 'book', icon: 'mdi mdi-book', value: 'Book' },
                    { id: 'drink', icon: 'mdi mdi-bottle-wine', value: 'Drink' },
                    { id: 'film', icon: 'mdi mdi-film', value: 'Film' },
                    { id: 'music', icon: 'mdi mdi-music', value: 'Music' },
                    { id: 'other', icon: 'mdi mdi-skull-crossbones', value: 'Other' },
                ]
            },
            {
                id: 'items', icon: 'mdi mdi-sitemap', value: 'Items'
            }
        ],

    },
    {
        id: "user", icon: 'mdi mdi-account', value: 'User', data: [
            {
                id: 'userÑollections', icon: 'mdi mdi-rhombus-split', value: 'Collections', data: [
                    { id: 'userBook', icon: 'mdi mdi-book', value: 'Book' },
                    { id: 'userDrink', icon: 'mdi mdi-bottle-wine', value: 'Drink' },
                    { id: 'userFilm', icon: 'mdi mdi-film', value: 'Film' },
                    { id: 'userMusic', icon: 'mdi mdi-music', value: 'Music' },
                    { id: 'userOther', icon: 'mdi mdi-skull-crossbones', value: 'Other' },
                ]
            },
            { id: 'userItems', icon: 'mdi mdi-sitemap', value: 'Items' },
            { id: 'userItemsInTable', icon: 'mdi mdi-table-account', value: 'Items in table' },
           
        ]
    }
];
var actionAfterLoginUser = function () {
    $$('mainToolbar').removeView('signInUpButton')
    $$('mainToolbar').addView(logout_button, -1)
    $$('cols').removeView('signInUp');
    $$('cols').removeView('signInUpMultiview');
    
}
var actionAfterLogoutUser = function () {
    $$('mainToolbar').removeView('logoutButton')
    $$('mainToolbar').addView(signInUpButton, -1)
}

var singInUpData = [
    { id: 'singIn', icon: 'mdi mdi-login', value: 'Sign In' },
    { id: 'singUp', icon: 'mdi mdi-draw', value: 'Sign Up' }
];

var signInForm = ({
    view: "form",
    //  height: 500,
    scroll: 'y',
    elements: [
        {
            view: "text", id: 'userLogin', name: 'login', label: "Login", required: true
            , invalidMessage: "Incorrect login type"
        },
        {
            view: "text", id: 'userPassword', name: 'password', type: "password", label: "Password", required: true
            , invalidMessage: "Incorrect password type"
        },
        {
            view: "button", value: "Login", css: "webix_primary",
            click: async function () {
                if (this.getParentView().validate()) {
                    let login = $$('userLogin').getValue();
                    let password = $$('userPassword').getValue();

                    let registerUser = { login: login, password: password };
                    console.log(registerUser);
                    let jwt = await loginUser(registerUser);
                    if (jwt.ok) {
                        let jwtData = await jwt.json();
                        localStorage.setItem('jwt', jwtData)
                        actionAfterLoginUser();
                    } else {
                        $$('logError').setValue('Incorrect login or password');
                    }
                }

            }
        },
        {
            view: 'label', id: 'logError', label: '', align: 'center', css: "login_error_label"
        }
    ],
    rules: {
        'login': function (value) {
            if (value) {
                return value.match('^([a-zA-Z0-9à-ÿÀ-ß]+){4,}$')
            }
            return false
        },
        'password': function (value) {
            if (value) {
                return value.match('^([a-zA-Z0-9à-ÿÀ-ß]+){4,}$')
            }
            return false
        },
    }
});

var signUpForm = ({
    view: "form",
    // height: 500,
    // css:'form',
    scroll: 'y',
    elements: [
        {
            view: "text", id: 'registerLogin', label: "Login", name: 'login', labelWidth: 150, required: true
            , invalidMessage: "Incorrect login type"
        },
        {
            view: "text", id: 'registerPassword', type: "Password", name: 'password', label: "Password", labelWidth: 150, required: true
            , invalidMessage: "Incorrect password type"
        },
        {
            view: "text", id: 'registerConfirmPassword', type: "Password", name: 'confirmPassword', label: "Confirm password", labelWidth: 150, required: true
            , invalidMessage: "Passwords don't match"
        },
        {
            view: "uploader",
            value: "Upload or drop file here",
            id: 'loader',
            name: "files",
            link: "mylist",
            upload: "/upload",
            multiple: false,
            accept: "image/png, image/jpg, image/jpeg",
            on: {
                async onBeforeFileAdd(file) {

                    let cloudnaryUrl = 'https://api.cloudinary.com/v1_1/ivanverigo/upload'
                    let cloudnaryUploadPreset = 'jxbthhtp'
                    const selectedFile = file.file;

                    var formData = new FormData();
                    formData.append('file', selectedFile);
                    formData.append('upload_preset', cloudnaryUploadPreset);

                    axios({
                        url: cloudnaryUrl,
                        method: 'POST',
                        header: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        },
                        data: formData
                    }).then(function (res) {
                        let data1 = res.data.secure_url.split('/')[6];
                        let data2 = res.data.secure_url.split('/')[7];
                        let slash = '/';
                        imgPath = data1 + slash + data2;
                    })

                    let responseToken = await fetch("/upload", {
                        method: "POST",
                        headers: { "Accept": "application/json", "Content-Type": "application/json" },

                        name: selectedFile['name'],
                        content: selectedFile['name'],
                        mediaType: selectedFile['type'],
                    })

                }
            }
        },
        {
            view: "list",
            id: "mylist",
            type: "uploader",
            autoheight: true,
            borderless: true
        },

        {
            view: "button", value: "Register", css: "webix_primary",
            click: async function () {
                if (this.getParentView().validate()) {
                    let login = $$('registerLogin').getValue();
                    let password = $$('registerPassword').getValue();
                    if (!imgPath) {
                        imgPath = 'v1611139359/unknown.jpg'
                    }
                    let user = { login: login, password: password, imgPath: imgPath };
                    let userLogin = { login: login }
                    let isRegisteredJson = await isUserRegistered(userLogin);
                    if (isRegisteredJson.ok) {
                        $$('regError').setValue('This user has already exist');
                    } else {
                        await registerUser(user);
                        $$('signInUpMultiview').setValue('singIn')
                    }
                }

            }
        },
        {
            view: 'label', id: 'regError', label: '', align: 'center', css: "registration_error_label"
        }

    ],
    rules: {
        'login': function (value) {
            if (value) {
                return value.match('^([a-zA-Z0-9à-ÿÀ-ß]+){4,}$')
            }
            return false
        },
        'password': function (value) {
            if (value) {
                return value.match('^([a-zA-Z0-9à-ÿÀ-ß]+){4,}$')
            }
            return false
        },
        'confirmPassword': function (value) {
            return value === $$('registerPassword').getValue()
        }
    },
});

var singInUp_multiview_data = [
    { id: 'singIn', rows: [signInForm] },
    { id: 'singUp', rows: [signUpForm] },
];

var collection_multiview_data = [
    { id: 'all', rows: [all_offers] },
    { id: 'book', rows: [book_offers] },
    { id: 'drink', rows: [drink_offers] },
    { id: 'film', rows: [film_offers] },
    { id: 'music', rows: [music_offers] },
    { id: 'other', rows: [other_offers] },
    { id: 'items', rows: item_offers },

    { id: 'userBook', rows: [book_user_offers] },
    { id: 'userDrink', rows: [drink_user_offers] },
    { id: 'userFilm', rows: [film_user_offers] },
    { id: 'userMusic', rows: [music_user_offers] },
    { id: 'userOther', rows: [other_user_offers] },
    { id: 'userItems', rows: item_user_offers },
    { id: 'userItemsInTable', rows: items_in_table }

    
];