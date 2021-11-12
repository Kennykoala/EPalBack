
new Vue({
    el: '#gameapp',
    data: {
        items: [],
        breadcrumbs: [
            {
                text: '首頁',
                href: '/EpalBack/Home'
            },
            {
                text: '遊戲列表',
                active: true
            }
        ],
        fields: [
            { key: 'gameCategoryId', label: '遊戲編號', sortable: true },
            { key: 'gameName', label: '遊戲名稱', sortable: true },
            { key: 'gameCoverMini',label: '遊戲縮圖', sortable: false, class: 'coverMini' },
            { key: 'gameCover', label: '遊戲背景', sortable: false, class:'bkImg' },
            { key: 'gameAlias', label: '遊戲別名', sortable: true },
            { key: 'playerCount', label: '玩家數量', sortable: true },
            { key: 'manage', label: '遊戲管理'}
        ],
        perPage: 3,
        currentPage: 1,
        rows: 1,
        perPage: 5,
        pageOptions: [5, 10, 20],
        modalShow: false,
        enableEdit: false,
        gameModel: {
            id: '?',
            fields: [
                { key: 'gameCategoryId', label: '遊戲編號', value: '' },
                { key: 'gameName', label: '遊戲名稱', value: '' },
                { key: 'gameCoverMini',label: '遊戲縮圖', value: '' },
                { key: 'gameCover', label: '遊戲背景', value: '' },
                { key: 'gameAlias', label: '遊戲別名', value: '' },
                { key: 'playerCount', label: '玩家數量', value: '' },
            ]

        },
        modalData: {
            gameCategoryId: '',
            gameName: '',
            gameCoverMini: '',
            gameCover: '',
            gameAlias: '',
            playerCount: ''
        }
    },
    methods: {
        showModal() {
            this.modalShow = !this.modalShow
        },
        gameInfo(index) {
            // console.log(index)
            // console.log(this.items[index])
            this.title='hi'
            // console.log(this.fields[1].key)
            this.modalData.gameCategoryId = this.items[index].gameCategoryId
            this.modalData.gameName = this.items[index].gameName
            this.modalData.gameCoverMini = this.items[index].gameCoverMini
            this.modalData.gameCover = this.items[index].gameCover
            this.modalData.gameAlias = this.items[index].gameAlias
            this.modalData.playerCount = this.items[index].playerCount
            // console.log(this.modalData)
        },


    },
    created() {
        this.totalRows = 0
        
    },
    computed() {
        
        // console.log(this.totalRows)
    },
    mounted() {

            let cfg = {
                method: 'get',
                headers: {
                    'Content-type': 'application/json',
                },
                url: '/api/games/getgames'
            };
            axios(cfg)
                .then(res => {
                    // console.log(res.data)
                    // if(res.stat)
                    if (res.status == 200){
                        // this.items = res.result
                        this.items = res.data.result
                        this.rows = this.items.length
                        // console.log(this.items)
                    }
                    
                })
                .catch(err => {
                    // An error occurred
                })
            
    
    
        
    }

})