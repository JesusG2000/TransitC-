function collectionData(header, data, isCollapsed) {
    return {
        header: header,
        collapsed: isCollapsed,
        body: {
            rows: [
                {
                    view: 'dataview',
                    id: 'dataview',
                    data: data,
                    css: 'collection_box',
                    //xCount: 3,
                    item: {

                        height: 340,
                        width: 400
                    },
                    /*on: {
                        // the default click behavior that is true for any datatable cell
                        onItemDblClick: function (e, id, node) {
                            {
                                $$("my_popup").show();
                            }
                        }
                    },*/
                    template: `<div class='content'>

<img src="https://res.cloudinary.com/ivanverigo/image/upload/#pathToImg#" height="80%" width="100%" alt="No img"/>
<h1>#name#</h1>
<div class="module">
  <p>#description#</p>
</div>
</div>
`
                }


            ]
        }
    };
}


var book_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Books', getCollection('BOOKS'), false)
    ]
});
var drink_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Drinks', getCollection('DRINKS'), false)
    ]
});
var film_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Films', getCollection('FILMS'), false)
    ]
});
var music_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Music', getCollection('MUSIC'), false)
    ]
});
var game_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Games', getCollection('GAMES'), false)
    ]
});
var other_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Others', getCollection('OTHERS'), false)
    ]
});
var all_offers = ({
    view: 'accordion',
    multi: false,
    type: 'space',
    rows:
        [
            collectionData('Books', getCollection('BOOKS'), false),
            collectionData('Drinks', getCollection('DRINKS'), true),
            collectionData('Films', getCollection('FILMS'), true),
            collectionData('Music', getCollection('MUSIC'), true),
            collectionData('Games', getCollection('GAMES'), true),
            collectionData('Others', getCollection('OTHERS'), true)
        ]
});
var item_offers =
    [

        {
            view: "scrollview",
            scroll: "x",
            id: 'scrollview',
            body:
            {
                view: "kanban",
                id: 'generalBoard',
                cols: [
                    {
                        header: "Book",
                        body: { view: "kanbanlist", status: "new", type: "cards" }
                    },
                    {
                        header: "Drink",
                        body: { view: "kanbanlist", status: "work", type: "cards" }
                    },
                    {
                        header: "Film",
                        body: { view: "kanbanlist", status: "test", type: "cards" }
                    },
                    {
                        header: "Music",
                        body: { view: "kanbanlist", status: "done", type: "cards" }
                    },
                    {
                        header: "Game",
                        body: { view: "kanbanlist", status: "done", type: "cards" }
                    },
                    {
                        header: "Other",
                        body: { view: "kanbanlist", status: "done", type: "cards" }
                    }

                ],



                data: task_set_with_comments,
                tags: tags_set,
                users: users_set,

                comments: true,
                userList: true

            }
        }
    ];

var book_user_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Books', getUserCollection('BOOKS'), false)
    ]
});
var drink_user_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Drinks', getUserCollection('DRINKS'), false)
    ]
});
var film_user_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Films', getUserCollection('FILMS'), false)
    ]
});
var music_user_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Music', getUserCollection('MUSIC'), false)
    ]
});
var game_user_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Games', getUserCollection('GAMES'), false)
    ]
});
var other_user_offers = ({
    view: 'accordion',
    type: 'space',
    rows: [
        collectionData('Others', getUserCollection('OTHERS'), false)
    ]
});
var item_user_offers = [
    {
        view: "button",
        css: "webix_primary",
        label: "Add new card",
        click: () => {
            $$("myBoard").showEditor();
        }
    },
    {
        view: "scrollview",
        scroll: "x",
        id: 'scrollview',
        body:
        {
            view: "kanban",
            id: 'myBoard',

            cols: [
                {
                    header: "Book",
                    body: { view: "kanbanlist", status: "books", type: "cards" }
                },
                {
                    header: "Drink",
                    body: { view: "kanbanlist", status: "drinks", type: "cards" }
                },
                {
                    header: "Film",
                    body: { view: "kanbanlist", status: "films", type: "cards" }
                },
                {
                    header: "Music",
                    body: { view: "kanbanlist", status: "music", type: "cards" }
                },
                {
                    header: "Game",
                    body: { view: "kanbanlist", status: "games", type: "cards" }
                },
                {
                    header: "Other",
                    body: { view: "kanbanlist", status: "others", type: "cards" }
                }
            ],
            editor: [
                {
                    view: "richselect",
                    id: 'typeList',
                    name: "typeList",
                    label: "Type",
                    options: [
                        { id: "0", value: "books" },
                        { id: "1", value: "drinks" },
                        { id: "2", value: "films" },
                        { id: "3", value: "music" },
                        { id: "4", value: "games" },
                        { id: "5", value: "others" }
                    ],
                    on: {
                        async onChange(current, prev) {

                            if ($$('collectionList')) {
                                this.getParentView().removeView('collectionList');
                            }
                            this.getParentView().addView(
                                {
                                    view: "richselect",
                                    id: "collectionList",
                                    name: "collectionList",
                                    label: "Collection",
                                    labelPosition: "top",
                                    options: await getUserCollectionForRichselect($$('typeList').getText()),
                                    on: {
                                        async onChange(current, prev) {
                                            let collectionName = $$('collectionList').getText();
                                            let fields = await userCollectionFields(collectionName);
                                            console.log(fields);
                                            for (let i = 0; i < fields.length; i++) {
                                                let view;
                                                switch (fields[i]['typeString']) {
                                                    case 'INT':
                                                        {
                                                            view = { view: 'text', id: fields[i]['name'], type: 'number', label: fields[i]['name'], labelPosition: "top", required: true}
                                                            break;
                                                        }
                                                    case 'STRING':
                                                        {
                                                            view = { view: 'text', id: fields[i]['name'], type: 'text', label: fields[i]['name'], labelPosition: "top", required: true }
                                                            break;
                                                        }
                                                    case 'TEXT':
                                                        {
                                                            view = { view: "textarea", id: fields[i]['name'], height: 60, label: fields[i]['name'], labelPosition: "top", required: true }
                                                            break;
                                                        }
                                                    case 'DATE':
                                                        {
                                                            view = { view: "datepicker", id: fields[i]['name'], label: fields[i]['name'], stringResult: true, format: "%d  %M %Y", labelPosition: "top", required: true }
                                                            break;
                                                        }
                                                    case 'BOOL':
                                                        {
                                                            view = { view: 'checkbox', id: fields[i]['name'], label: fields[i]['name'],labelPosition: "top",}
                                                            break;
                                                        }
                                                }
                                                this.getParentView().addView(view,-1);
                                            }
                                        }
                                    }
                                },1);
                                    
                        }
                    }
                },

                {
                    view: "text", id: 'itemName', name: 'itemName', label: "Name", required: true
                },
                {
                    view: "textarea", name: "itemDescription", height: 90, label: "Description", required: true
                },
                {
                    view: 'checkbox',
                    label: 'Switch to custom tags',
                    on: {
                        onChange(firstValue, secondValue) {

                            if (firstValue) {
                                this.getParentView().addView({
                                    view: "text",
                                    id: 'custom_tag',
                                    name: 'tags',
                                    label: "Custom tags",
                                    labelPosition: "top",
                                    on: {
                                        onBlur() {
                                            //  tags_set[tags_set.length] = { id: 'some', value: 'some' };
                                            //localStorage.setItem('l','some');
                                            // $$('scrollview').refresh();
                                        }
                                    }
                                },
                                    5);
                                this.getParentView().removeView('tag_list');

                            } else {
                                this.getParentView().addView({
                                    view: "multicombo",
                                    id: 'tag_list',
                                    name: "tags",
                                    label: "Tags",
                                    labelPosition: "top",
                                    options: tags_set

                                },
                                    5);
                                this.getParentView().removeView('custom_tag');
                            }
                        }
                    }
                },
                {
                    view: "multicombo",
                    id: 'tag_list',
                    name: "tags",
                    label: "Tags",
                    labelPosition: "top",
                    options: tags_set,

                },
                //{
                //    cols: [
                //        {
                //            name: "user_id",
                //            view: "combo",
                //            options: users_set,
                //            label: "Assign to"
                //        },
                //        //{
                //        //    view: "richselect",
                //        //    name: "color",
                //        //    label: "Priority",
                //        //    options: {
                //        //        body: {
                //        //            data: colors_set,
                //        //            css: "webix_kanban_colorpicker",
                //        //            template:
                //        //                "<span class='webix_kanban_color_item' style='background-color: #color#'></span>#value#"
                //        //        }
                //        //    }
                //        //},

                //    ]
                //},
                {
                    view: "uploader",
                    value: "Upload or drop file here",
                    id: 'loader',
                    name: "files",
                    link: "mylist",
                    upload: "/upload",
                    multiple: false,
                    accept: "image/png, image/jpg, image/jpeg"
                },
                {
                    view: "list",
                    id: "mylist",
                    type: "uploader",
                    autoheight: true,
                    borderless: true
                }
            ],
            data: task_set_with_comments,
            tags: tags_set,
            users: users_set,
            colors: colors_set,
            comments: true,
            userList: true,
            cardActions: true,
            on: {
                onDataUpdate() {
                    console.log(tags_set);
                    $$('myBoard').refresh();
                }
            }

        }
    }
];

var items_in_table = [
    {
        cols: [
            { view: 'button', label: 'Add', type: 'iconButton', icon: 'plus' },
            {
                view: 'button', label: 'Delete', type: 'iconButton', icon: 'trash',
                click: function () {
                    var sel = $$('userDatatable').getSelectedId();
                    if (sel) $$('userDatatable').remove(sel.row)
                    else return false
                }
            }
        ]
    },
    {
        view: "datatable",
        id: "userDatatable",
        data: task_set_with_comments,
        resizeColumn: true,
        columns: [
            { id: 'id', header: [{ text: '<span class="mdi mdi-filter"></span>' }], width: 50, sort: 'int' },
            { id: 'status', header: [{ text: 'status' }, { content: 'textFilter' }], editor: 'text' },
            { id: 'text', header: [{ text: 'Text' }], fillspace: true },
            {
                id: 'tags', header: [{ text: 'Tags count' }], width: 150, sort: 'int',
                template: function (obj) {
                    return obj['tags'].length;
                }
            },
            { header: [{ text: 'Actions' }], template: ' {common.editIcon}', width: 60 }
        ],
        scroll: false,
        type: {
            trashIcon: '<span class="mdi mdi-delete"></span>',
            editIcon: '<span class="webix_kanban_icon kbi-pencil"></span>'
        },
        pager: 'pager',
        select: true,
        editable: true,
        editaction: 'dblclick'
        //borderless:true,
        //yCount:13
        //autoConfig: true
    },
    {
        view: 'pager',
        id: 'pager',
        size: 13,
        group: 10,
        template: `{common.first()} {common.prev()} {common.pages()}
            {common.next()} {common.last()}`
    }
]

async function getUserCollection(type) {
    let res = await isUserLoggedIn();
    if (res.ok) {
        let user = await res.json();
        res = await getCollectionsByUserIdAndType(user['id'], type);
        if (res.ok) {

            let collection = await res.json();

            return collection;
        }
    }
    return [];
}
async function getCollection(type) {
    let res = await getCollectionsByType(type);
    if (res.ok) {

        let collection = await res.json();

        return collection;
    }
    return [];
}
async function getUserCollectionForRichselect(type) {

    let collections = await getUserCollection(type);
    richSelectData = [];
  //  console.log(collections)
    for (let i = 0; i < collections.length; i++) {
        richSelectData[i] = { id: i, value: collections[i]['name'] }
    }
    return richSelectData;

}

async function userCollectionFields(collectionName) {
    let res = await isUserLoggedIn();
    if (res.ok) {
        let user = await res.json();
        res = await getUserCollectionFields(collectionName);
        if (res.ok) {

            let fields = await res.json();

            return fields;
        }
    }
    return [];
}