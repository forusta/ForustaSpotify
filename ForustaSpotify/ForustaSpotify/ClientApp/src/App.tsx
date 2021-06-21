import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import AuthPage from './components/auth/AuthPage';
import ArtistList from './components/artists/ArtistSearch';
import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/auth' component={AuthPage} />
        <Route path='/artists-search' component={ArtistList} />
    </Layout>
);
