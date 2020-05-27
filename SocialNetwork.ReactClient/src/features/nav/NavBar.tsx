﻿import React, { useContext } from 'react';
import { Container, Menu, Button } from 'semantic-ui-react';
import activityStore from '../../stores/activityStore';

const NavBar: React.FC = () => {
    const activityStoreObj = useContext(activityStore);

    const onCreateActivityHandler = () => {
        activityStoreObj.setSelectActivity("");
        activityStoreObj.setShowFormFlag(true);
    }

    return (
        <Menu fixed="top" inverted>
            <Container>
                <Menu.Item header>
                    <img src="assets/logo.png" alt="logo" />
                    Social Network
                </Menu.Item>

                <Menu.Item name='Activities' />
                <Menu.Item>
                    <Button onClick={() => onCreateActivityHandler() } content="Create Activity" positive />
                </Menu.Item>
            </Container>
        </Menu>
    )
};

export default NavBar;
