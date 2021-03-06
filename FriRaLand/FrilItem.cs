﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriRaLand {
    class FrilItem {
        public string item_id;
        public string item_name;
        public string detail;
        public int s_price;
        public int status;
        public int t_status;
        public int carriage;
        public int d_method;//delivery_method
        public int d_date;//delivery_date
        public int d_area;//delivary_from_area;
        public string user_id;//出品者ID
        public DateTime created_at;//ex)2017-09-27T09:12:57+09:00
        public string screen_name; //出品者アカウント名
        public int category_id;
        public int category_p_id;//parent?
        public int size_id; //19999=>なし
        public string size_name;
        public int brand_id; //null
        public int i_brand_id;
        public int commens_count;
        public int likes_count;
        public string[] imageurls = new string[4]; //画像URL
        public string[] imagepaths = new string[4]; //ローカルの画像パス
        public FrilItem() {

        }
        public FrilItem(dynamic json) {
            //info
            var info = json.info;
            this.item_id = ((long)info.item_id).ToString();
            this.item_name = info.item_name;
            this.detail = info.detail;
            this.s_price = (int)info.s_price;
            this.status = (int)info.status;
            this.t_status = (int)info.t_status;
            this.carriage = (int)info.carriage;
            this.d_method = (int)info.d_method;
            this.d_date = (int)info.d_date;
            this.d_area = (int)info.d_area;
            this.created_at = DateTime.Parse((string)info.created_at);
            this.user_id = ((long)info.user_id).ToString();
            this.screen_name = info.screen_name;
            this.category_id = (int)info.category_id;
            this.category_p_id = (int)info.category_p_id;
            this.size_id = (int)info.size_id;
            this.size_name = info.size_name;
            this.brand_id = (info.brand_id == null) ? -1 : (int)info.brand_id;
            this.i_brand_id = (info.i_brand_id == null) ? -1 : (int)info.i_brand_id;
            //image
            for (int i = 0; i < 4; i++) imageurls[i] = "";
            int num = 0;
            foreach (var image in json.imgs) {
                imageurls[num++] = image.file_name;
            }
            //comment,like
            this.commens_count = (int)json.comments_count;
            this.likes_count = (int)json.likes_count;
        }
    }
}
