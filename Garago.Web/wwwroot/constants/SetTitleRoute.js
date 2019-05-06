import React from 'react';
import { Switch, Route } from 'react-router';
import * as utils from '../utilities/utils';


const SetTitleRoute = (props) => {
    return (
            <Route exact={props.exact} path={props.path} render={() => {
                utils.setDocTItle(props.title, props.justTitle);

                return React.cloneElement(props.children, props);
            }} />
    );
}

export default SetTitleRoute;