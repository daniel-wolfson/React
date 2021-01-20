import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './app';

test('renders learn react link', () => {
  render(<App />);
  const linkElement = screen.getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});

const fakeAxois = {
  get: (url: string, waitLonger = 200) => new Promise(function(resolve, reject) {
    const wait = Math.floor(Math.random() * Math.floor(300)) + waitLonger;
    setTimeout(resolve, wait, {data: {docs: url + ' data fetched'}});
  })
}

export default fakeAxois