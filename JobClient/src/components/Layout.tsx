import React, { Component } from 'react';
import { Container } from 'reactstrap';
// import { NavMenu } from './NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div className="h-100">
        <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.min.css' />
        {/* <NavMenu /> */}
        <Container className="d-flex align-items-center h-100">
          {this.props.children}
        </Container>
      </div>
    );
  }
}

