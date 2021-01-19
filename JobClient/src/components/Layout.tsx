import React, { Component } from 'react';
import { Container } from 'reactstrap';
// import { NavMenu } from './NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div className="h-100">
        
        {/* <NavMenu /> */}
        <Container className="d-flex align-items-center h-100">
          {this.props.children}
        </Container>
      </div>
    );
  }
}

