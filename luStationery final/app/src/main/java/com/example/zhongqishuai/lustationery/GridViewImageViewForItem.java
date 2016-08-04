package com.example.zhongqishuai.lustationery;

import android.content.Context;
import android.util.AttributeSet;
import android.widget.ImageView;

/**
 * Created by zhongqishuai on 12/3/16.
 */
public class GridViewImageViewForItem extends ImageView{


        public GridViewImageViewForItem(Context context)
        {
            super(context);
        }

        public GridViewImageViewForItem(Context context, AttributeSet attrs)
        {
            super(context, attrs);
        }

        public GridViewImageViewForItem(Context context, AttributeSet attrs, int defStyle)
        {
            super(context, attrs, defStyle);
        }

        @Override
        protected void onMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            super.onMeasure(widthMeasureSpec, heightMeasureSpec);
            setMeasuredDimension(getMeasuredWidth(), getMeasuredWidth()); //Snap to width
        }

}
