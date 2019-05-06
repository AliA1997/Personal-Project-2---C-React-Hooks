
export const basisArray = [
    "small",
    "medium",
    "1/4"
];

export const heightArray = [    
    "xsmall",
    "small",
    "medium",
    "large",
]

export function getTopMargin(height, width) {
    if(height === 'xsmall')
        return '-5px';
    else if(height === 'small')
        return '-5px';
    else if(height === 'small' && width === 'small')
        return '-25px';
    else if((height === 'large' || height === 'medium') && (width === '1/4' || width === 'medium'))
        return '0px';
    else if(height === 'medium')
        return '-5px';
}

export function getImageWidth(width) {
    if(width === 'xsmall' || width === 'small')
        return '100%';
    else if(width === 'medium')
        return '275px';
    else if(width === '1/4')
        return '350px';
}

///Define an method that will return a array with your animation based if your item is hovered or clicked.
export function defineAnimationArray(item, isHovered, animationObj) {
    console.log('isHovered-----------------', isHovered);
    if(item === isHovered)
        return animationObj;
    
        animationObj['duration'] = 0;
        return animationObj;
}

export const theme = { 
    global: { 
        colors: { 
            doc: '#ff99cc' 
        },
        breakpoints: {
          xsmall: {
            value: 500,
          },
          small: {
            value: 900,
          },
          medium: undefined,
          middle: {
            value: 2000,
          },
        },
    },
}