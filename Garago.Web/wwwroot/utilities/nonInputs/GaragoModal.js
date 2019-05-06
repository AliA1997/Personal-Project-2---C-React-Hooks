import React from 'react';
import { Layer, Paragraph, Heading } from 'grommet';
import PropTypes from 'prop-types';

const GaragoModal = ({onEscape, onClickOutside, backgroundColor, messages, header}) => {
    return (
        <Layer
            onEsc={onEscape}
            onClickOutside={onClickOutside}
            style={{background: backgroundColor ? 'green' : 'unset'}}
        >
            <Heading responsive={true} size="medium">{header}</Heading>
            {
                messages && messages.length ?
                    messages.map(message => {
                        return <Paragraph size="medium">{message}</Paragraph>
                    })
                    : null
            }
        </Layer>
    );
};

GaragoModal.propTypes = {
    onEscape: PropTypes.func.isRequired,
    onClickOutside: PropTypes.func.isRequired,
    backgroundColor: PropTypes.string,
    messages: PropTypes.arrayOf(PropTypes.string),
    header: PropTypes.string.isRequired
}

export default GaragoModal;


