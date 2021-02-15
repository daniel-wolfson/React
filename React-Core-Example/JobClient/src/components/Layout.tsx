import React, { Component } from 'react';
import { Container } from 'reactstrap';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div className="h-100">
        <Container className="d-flex justify-content-center align-items-center h-100">
          {this.props.children}
        </Container>
      </div>
    );
  }
}

